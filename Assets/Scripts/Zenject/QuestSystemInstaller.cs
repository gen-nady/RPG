using QuestSystem;
using UnityEngine;
using Zenject;

public class QuestSystemInstaller : MonoInstaller
{
    [SerializeField] private PlayerQuest _playerQuest;
    [SerializeField] private PlayerQuestUI _playerQuestUI;
    [SerializeField] private QuestGiver _questGiver;
    [SerializeField] private QuestGiverUI _questGiverUI;
    
    public override void InstallBindings()
    {
        Container.Bind<PlayerQuest>().FromInstance(_playerQuest).AsSingle().NonLazy();
        Container.Bind<PlayerQuestUI>().FromInstance(_playerQuestUI).AsSingle().NonLazy();
        Container.Bind<QuestGiver>().FromInstance(_questGiver).AsSingle().NonLazy();
        Container.Bind<QuestGiverUI>().FromInstance(_questGiverUI).AsSingle().NonLazy();
    }
}