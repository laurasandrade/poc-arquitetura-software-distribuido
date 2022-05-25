export interface ListaMedico {
    data: [
        {
            idMedico: number,
            nome: string,
            email: string,
            telefone: string,
            idEspecialidade: 24
        }
    ];
    message: string;
    success: boolean;
    total: number;
}

export interface ListaEspecialidade {
    data: [
        {
          idEspecialidade: number,
          nome: string
        }
      ];
      message: string;
      success: boolean,
      total: number;
}

export interface ListaMedicoDelete {
    data: [
        {
            idMedico: number,
            nome: string,
            email: string,
            telefone: string,
            idEspecialidade: 24
        }
    ];
    message: string;
    success: boolean;
}