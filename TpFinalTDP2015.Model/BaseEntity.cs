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
        private int iId;
        private DateTime iCreationDate;
        private DateTime iLastModified;

        public BaseEntity()
        {
            this.iId = 0;
        }

        public virtual int Id
        {
            get { return this.iId; }
            set { this.iId = value; }
        }

        public virtual DateTime CreationDate
        {
            get { return this.iCreationDate; }
            set { this.iCreationDate = value; }
        }

        public virtual DateTime LastModified
        {
            get { return this.iLastModified; }
            set { this.iLastModified = value; }
        }

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
