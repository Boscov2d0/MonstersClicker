using System.Collections.Generic;
using UnityEngine;

namespace MonstersGame
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private UIView uI;

        /// <summary>
        /// Контроллер буста замарозки спавна
        /// </summary>
        FreezBoosterController boosterController;

        private PlayerController _playerController;
        private UIController _uIController;

        /// <summary>
        /// Список контроллеров созданных монстров
        /// </summary>
        private List<MainMonsterController> _mainMonsterControllers = new List<MainMonsterController>();
        /// <summary>
        /// Список объектов, реализующих Update
        /// </summary>
        ListUpdateObjects ListUpdateObjects;

        private MonsterSpawner _monstersSpawner;
        private BoostSpawner _boostSpawner;

        /// <summary>
        /// Список монстров на игровом поле
        /// </summary>
        private List<GameObject> monstersList = new List<GameObject>();

        private int _kiledCounter = 0;
        private int _levelsHard = 1;
        private bool _gameOver = false;

        private void Awake()
        {
            Time.timeScale = 1;
            _gameOver = false;

            _monstersSpawner = new MonsterSpawner();
            _boostSpawner = new BoostSpawner();

            _monstersSpawner.AddMonsterToList += AddMonsterToList;

            _playerController = new PlayerController(_player);
            _uIController = new UIController(uI);

            ListUpdateObjects = new ListUpdateObjects();

            _playerController.TapOnMonster += TapOnMonster;
            _playerController.TapOnBoost += TapOnBoost;
        }

        private void Update()
        {
            if (!_gameOver)
            {
                if (boosterController != null)
                {
                    boosterController.MyUpdate();
                }
                _playerController.MyUpdate();

                if (ListUpdateObjects.Length > 0)
                {
                    for (int i = 0; i < ListUpdateObjects.Length; i++)
                    {
                        ListUpdateObjects[i].MyUpdate();
                    }
                }

                _monstersSpawner.SpawnTimer();
                _boostSpawner.SpawnTimer();

                if (monstersList.Count >= 10)
                {
                    GameOver();
                }
            }
        }

        /// <summary>
        /// Событие, вызываемое во время нажатия на монстра
        /// </summary>
        /// <param name="boost"></param>
        private void TapOnMonster(Monster monster, int forceOfDamage)
        {
            monster.GetComponent<Monster>();
            MonsterDeathController monsterDeathController = new MonsterDeathController(monster);
            if (monsterDeathController.HealthChange(forceOfDamage))
            {
                _monstersSpawner.Deactivate(monster);
                LevelChecker();
            }

            monstersList.Remove(monster.gameObject);
        }

        /// <summary>
        /// Событие, вызываемое во время нажатия на бусты
        /// </summary>
        /// <param name="boost"></param>
        private void TapOnBoost(Booster boost)
        {
            if (boost is FreezeBoost)
            {
                boosterController = new FreezBoosterController(boost as FreezeBoost);
                boosterController.StartFreez(_monstersSpawner);
            }
            else
            {
                DestroyBoostController destroyBoostController = new DestroyBoostController();
                destroyBoostController.Destroy(_monstersSpawner, monstersList);
            }
            _boostSpawner.Deactivate(boost);
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            _gameOver = true;
            _uIController.ShowGameOver();
        }

        /// <summary>
        /// Вызываем после деактивации монстра с поля.
        /// Ставим засечку и проверяем, достойны ли мы повышения уровня.
        /// </summary>
        private void LevelChecker()
        {
            _kiledCounter++;

            if (_kiledCounter % 5 == 0)
            {
                _levelsHard++;
                RiseHardLevel();
            }
            _uIController.ShowLevel(_levelsHard.ToString());
        }

        /// <summary>
        /// Реализуем событие, вызванное в _monstersSpawner. 
        /// Берем созданного монстра и добавляем в лист GameObject, который служит для отслеживания монстров на поле.
        /// Так же создаем контроллер монстра и добавляем его в список объектов, реализующих Update
        /// Для вызова Update у всех
        /// </summary>
        private void AddMonsterToList()
        {
            GameObject _monster = _monstersSpawner.Monster;
            monstersList.Add(_monster);
            MainMonsterController _monsterController = new MainMonsterController(_monster.GetComponent<Monster>());
            ListUpdateObjects.AddUpdateObjects(_monsterController);
            _mainMonsterControllers.Add(_monsterController);
        }

        /// <summary>
        /// На каждом уровне усложняются определенные моменты
        /// </summary>
        private void RiseHardLevel()
        {
            switch (_levelsHard)
            {
                //Увеличиваем скорость движения
                case 2:
                    for (int i = 0; i < _mainMonsterControllers.Count; i++)
                    {
                        GlobalBase.MonsterSpeed += 0.001f;
                        _mainMonsterControllers[i].RiseSpeed();
                    }
                    break;
                //Добавляем второй вид монстра
                case 3:
                    _monstersSpawner.MaxLevelOfMonster++;
                    break;
                //Уменьшаем количество времени между спавном монстров
                case 4:
                    GlobalBase.TimeToSpawn--;
                    _monstersSpawner.InitTimeSpawn();
                    break;
                //Добавляем третий вид монстра
                case 5:
                    _monstersSpawner.MaxLevelOfMonster++;
                    break;
                //Увеличиваем количество жизней монстру(не успел)
                case 6:
                    //riseHP
                    break;
                default:
                    break;
            }
        }
    }
}