using ShoppingCart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShoppingCart.Core.DataAccess
{
    public interface IEntityRepository<T> where  T: class,IEntity,new() 
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //Veri talebinde bulunurken string, uniq, nesne vb. tipler gelebilirler bu yüzden dinamik olmalıdır. Bu yüzden de Lamda'nın base sınıfını parametre olarak alıyorum. Expression içersindeki Func da oraya bir Lambda sorgusunun geleceğini ifade ediyor. Hiçbir şey gelmemesi durumunda da default değer olarak null atıyoruz.
        T Get(Expression<Func<T, bool>> filter = null);

        //Parametreyi dinamize ediyoruz.
        List<T> GetList(Expression<Func<T, bool>> filter = null);
    }
}
