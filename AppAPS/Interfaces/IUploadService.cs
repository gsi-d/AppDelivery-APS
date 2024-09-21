using Microsoft.AspNetCore.Components.Forms;

namespace AppAPS.Interfaces
{
    public interface IUploadService
    {
        Task<(int, string)> ArquivoUploadAsync(IBrowserFile arquivo);
    }
}
