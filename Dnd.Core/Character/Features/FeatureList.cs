namespace Dnd.Core.Character.Features
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class FeatureList : IEnumerable<Feature>
    {
        private List<Feature> _list = new List<Feature>();

        public void AddFeature(Feature feature) {
            if (_list.Contains(feature)) {
                throw new InvalidOperationException("feature already added");
            }
            _list.Add(feature);
        }

        public int Count() {
            return _list.Count();
        }

        public IEnumerator<Feature> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}
