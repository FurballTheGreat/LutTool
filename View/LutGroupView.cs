using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using LutTool.Controllers;
using LutTool.Model;

namespace LutTool.View
{
    public class LutGroupView : BaseView {
        public int Index { get; }
        private readonly LutGroup _group;
        private readonly ControllerType _controller;

        public LutGroupView(int pIndex, LutGroup pGroup, ControllerType pController)
        {
            Index = pIndex;
            _group = pGroup;
            _controller = pController;

            foreach (var phase in _group.Phases) 
                Phases.Add(new LutPhaseView(phase.Key, phase.Value));
            foreach (var phaseGroup in _group.PhaseGroups)
                PhaseGroups.Add(new LutPhaseGroupView(phaseGroup.Key, phaseGroup.Value));
        }

        public uint RepeatCountingNumber
        {
            get => _group.RepeatCountingNumber;
            set
            {
                _group.RepeatCountingNumber = value;
                OnPropertyChanged(nameof(RepeatCountingNumber));
            }
        }

        public uint FrameRate
        {
            get => _group.FrameRate;
            set
            {
                _group.FrameRate = value;
                OnPropertyChanged(nameof(FrameRate));
            }
        }

        public ObservableCollection<LutPhaseView> Phases { get; } = new();
        public ObservableCollection<LutPhaseGroupView> PhaseGroups { get; } = new();
        public LutGroup Group => _group;

        public Visibility PhaseGroupsVisible =>
            _controller.HasPhaseGroups ? Visibility.Visible : Visibility.Collapsed;

        public Visibility FrameRatesVisibile =>
            _controller.HasFrameRates ? Visibility.Visible : Visibility.Collapsed;
    }
}