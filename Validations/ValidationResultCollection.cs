using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validations
{
    public class ValidationResultCollection : IEnumerable<ValidationResult>
    {
        private readonly List<ValidationResult> _results;

        public ValidationResultCollection()
        {
            _results = new List<ValidationResult>();
        }

        public int Count
        {
            get { return _results.Count; }
        }

        public bool IsValid
        {
            get { return _results.Count == 0; }
        }

        public void Add(ValidationResult item)
        {
            if (item == null)
                return;
            _results.Add(item);
        }

        public void AddResults(IEnumerable<ValidationResult> items)
        {
            if (items == null)
                return;
            foreach (var item in items)
            {
                _results.Add(item);
            }
        }

        public IEnumerator<ValidationResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}
