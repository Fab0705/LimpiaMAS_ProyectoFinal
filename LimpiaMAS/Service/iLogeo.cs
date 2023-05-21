using LimpiaMAS.Models;

namespace LimpiaMAS.Service
{
    public interface iLogeo
    {
        void LogeoComparision(string User, string Pwd);
        void LogeoPage(TbCliente cli, TbLimpiador limp);
    }
}
