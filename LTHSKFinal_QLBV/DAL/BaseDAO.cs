using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV.DAL
{
    public abstract class BaseDAO<T> where T: BaseEntity
    {
        private readonly LTHSKFinalDbDataContext dbContext = new LTHSKFinalDbDataContext();

        public Table<T> Table
        {
            get { return dbContext.GetTable<T>(); }
        }

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(string id)
        {
            return Table.Where(e => e.EntityId == id).FirstOrDefault();
        }

        public void Add(T entity)
        {
            if (Table.Where(e => e.Equals(entity)) != null)
                throw new ArgumentException("Entity muốn thêm đã tồn tại.");

            Table.InsertOnSubmit(entity);
            dbContext.SubmitChanges();
        }

        public void Update(T entity)
        {
            var oldEntity = Table.FirstOrDefault(e => e.Equals(entity));
            if (oldEntity == null)
                throw new ArgumentException("Entity muốn cập nhật không tồn tại.");

            oldEntity = entity;
            dbContext.SubmitChanges();
        }

        public void Delete(string id)
        {
            var entity = Table.FirstOrDefault(e => e.EntityId == id);
            if (entity == null)
                throw new ArgumentException("Entity muốn xóa không tồn tại.");

            Table.DeleteOnSubmit(entity);
            dbContext.SubmitChanges();
        }

        public int Count()
        {
            return Table.Count();
        }
    }
}
