export interface NovoCliente {
    data: {
        idMedico: number,
        nome: string,
        email: string,
        telefone: string,
        idEspecialidade: number,
        especialidadeEntity: {
          idEspecialidade: number,
          nome: string
        }
      };
    message: string;
    success: boolean;
}