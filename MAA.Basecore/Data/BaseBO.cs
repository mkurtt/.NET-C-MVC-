using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAA.Basecore.Data
{
    public class BaseBO : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public interface IBaseBO<T> where T : BaseModel
    {
        List<T> ListeyiGetir();

        T Getir(int id);

        bool Ekle(T nesne);

        bool Sil(int id);

        bool Guncelle(T nesne);

        //DataTable TabloGetir(Dictionary<string,object> keyValues);

    }
}
