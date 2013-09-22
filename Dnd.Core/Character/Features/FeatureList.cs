namespace Dnd.Core.Character.Features
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FeatureList : IEnumerable<Feature>
    {
        public int UnusedFeatures { get; private set; }

        private bool _creating;

        private readonly List<Feature> _list = new List<Feature>();

        public FeatureList() {
            _creating = true;
        }

        public void Add(Feature feature) {
            if (_list.Contains(feature)) {
                throw new InvalidOperationException("feature already added");
            }
            if (_creating || UnusedFeatures > 0) {
                _list.Add(feature);
                UsePoint();
            }
        }

        private void UsePoint() {
            if (UnusedFeatures > 0 && !_creating) {
                UnusedFeatures--;
            }
        }

        public void IncreaseFeatureCount(int amount) {
            UnusedFeatures += amount;
        }

        public int Count() {
            return _list.Count();
        }

        public void DoneCreating() {
            _creating = false;
        }

        public IEnumerator<Feature> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
