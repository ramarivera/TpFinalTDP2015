using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalTDP2015.Model
{
    [Serializable]
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.Id = 0;
        }

        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime LastModified { get; set; }



        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            BaseEntity lBase = obj as BaseEntity;
            if (lBase == null)
            {
                return false;
            }

            return (this.Id == lBase.Id);
        }

        public override int GetHashCode()
        {
            return !Object.ReferenceEquals(null, this) ? this.Id.GetHashCode() : 0;
        }


        public override string ToString()
        {
            return String.Format("{0} - {1}", this.GetType().Name, this.Id);
        }

    }
}
