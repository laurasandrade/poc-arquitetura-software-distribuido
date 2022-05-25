namespace poc.pos.arquiteturasoftwaredistribuido.api.Domain.Model
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Message = "Operação realizada com sucesso.";
            Success = true;
        }

        public T Data { get; set; } = default!;
        public string Message { get; set; } = default!;
        public bool Success { get; set; }
        public int? Total { get; set; }
    }
}
