namespace Dnd.Core.Model.Character.Features
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FeatureList : IEnumerable<Feature>
    {
        public int UnusedFeatures { get; private set; }

        private readonly List<Feature> _features = new List<Feature>();

        public FeatureList() {
        }

        public void Add(Feature feature) {
            if (_features.Contains(feature)) {
                throw new InvalidOperationException("feature already added");
            }
            if (UnusedFeatures > 0) {
                _features.Add(feature);
                UnusedFeatures--;
            }
        }

        public void IncreaseFeatureCount(int amount) {
            UnusedFeatures += amount;
        }

        public int Count() {
            return _features.Count();
        }

        public IEnumerator<Feature> GetEnumerator() {
            return _features.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
