using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using LutTool.Model;

namespace LutTool.View
{
    public class VoltageSourceView : BaseView
    {
        public int Lut { get; }
        private readonly Func<VoltageSource> _getSource;
        private readonly Action<VoltageSource> _setSource;
        public VoltageSource Source
        {
            get => _getSource();
            set
            {
                _setSource(value);
                OnPropertyChanged(nameof(Source));
            }
        }

        public VoltageSourceView(int pLut, Func<VoltageSource> pGetSource, Action<VoltageSource> pSetSource)
        {
            Lut = pLut;
            _getSource = pGetSource;
            _setSource = pSetSource;
          
        }

        public IEnumerable<VoltageSource> AvailableSources { get; } = Enum.GetValues<VoltageSource>().ToArray();
    }
}