using System;

class CelulaArvore
{
    private FluxoVeiculos CONTEUDO;
    private CelulaArvore ESQUERDO;
    private CelulaArvore DIREITO;
    private CelulaArvore RAIZ;
    private Pilha PILHA = new Pilha();
    private int MAXVALUE;
    private int MINVALUE;

    public CelulaArvore()
    {

    }
    public CelulaArvore(FluxoVeiculos elemento)
    {
        CONTEUDO = elemento;
    }
    public void inserir(FluxoVeiculos elemento)
    {
        if (RAIZ == null)
        {
            RAIZ = new CelulaArvore(elemento);
        }
        else
        {
            inserir(RAIZ, elemento);
        }
    }
    public void addPilha(FluxoVeiculos elemento)
    {
        PILHA.Push(elemento);
    }
    public void inserir(CelulaArvore celula, FluxoVeiculos elemento)
    {
        if (elemento.Fluxo < celula.CONTEUDO.Fluxo)
        {
            if (celula.DIREITO == null)
            {
                celula.DIREITO = new CelulaArvore(elemento);
            }
            else
            {
              //  Console.WriteLine("Inserir({0}) a Direita do Nó({1})", elemento.Fluxo, celula.CONTEUDO.Fluxo);
                inserir(celula.DIREITO, elemento);
            }
        }
        else if (elemento.Fluxo > celula.CONTEUDO.Fluxo)
        {
            if (celula.ESQUERDO == null)
            {
                celula.ESQUERDO = new CelulaArvore(elemento);
            }
            else
            {
               // Console.WriteLine("Inserir({0}) a Esquerda do Nó({1})", elemento.Fluxo, celula.CONTEUDO.Fluxo);
                inserir(celula.ESQUERDO, elemento);
            }
        }
        else
        {
            // Console.WriteLine("Inserir({0}) na pilha do Nó({1})", elemento.Fluxo, celula.CONTEUDO.Fluxo);
            celula.addPilha(elemento);
        }

    }
    public void Percorrer()
    {
        PreOrdem(RAIZ);
        Console.WriteLine("============================================");
    }
    public void percorrerPilha(CelulaArvore celula)
    {
        celula.PILHA.MOSTRAR_ELEMENTOS_PILHA();
    }
    public void MostrarConteudo(CelulaArvore celula)
    {
        Console.WriteLine(" ************************ ");
        Console.WriteLine("||   NÓ FLUXO :{0}",celula.CONTEUDO.Fluxo);
        Console.WriteLine(" ************************ ");
        Console.WriteLine("   |---> '1+' Setor:{0} Data:{1} Fluxo:{2}", celula.CONTEUDO.Setor
                                              , celula.CONTEUDO.Data
                                              , celula.CONTEUDO.Fluxo);
    }
    public void PreOrdem(CelulaArvore celula)
    {
        if (celula != null)
        {
            MostrarConteudo(celula);
            percorrerPilha(celula);
            PreOrdem(celula.DIREITO);
            PreOrdem(celula.ESQUERDO);
        }
    }
    public void ObterMinValue()
    {
        ProcurarMin(RAIZ);
        Console.WriteLine(" VALOR MINIMO NA ÁRVORE:{0}", MINVALUE);
    }
    public void ObterMaxValue()
    {
        ProcurarMax(RAIZ);
        Console.WriteLine(" VALOR MÁXIMO NA ÁRVORE:{0}", MAXVALUE);
    }
    public void ProcurarMax(CelulaArvore celula)
    {
        if (celula != null)
        {
            MAXVALUE = celula.CONTEUDO.Fluxo;
            ProcurarMax(celula.ESQUERDO);       
        }
    }
    public void ProcurarMin(CelulaArvore celula)
    {
        if(celula != null)
        {
            MINVALUE = celula.CONTEUDO.Fluxo;
            ProcurarMin(celula.DIREITO);
        }
    }
    public double CalcularFuncaoFiltro()
    {
        return MINVALUE + 0.8 * (MAXVALUE - MINVALUE);
    }
    public void PercorrerArvoreFluxos()
    {
        Console.WriteLine("============================================");
        double limite = CalcularFuncaoFiltro();
        Console.WriteLine(" MOSTRAR TODOS OS FLUXOS > {0} VEICULOS",limite);
        Console.WriteLine("============================================");
        MostrarFluxos(RAIZ, limite);
    }
    public void MostrarFluxos(CelulaArvore celula, double limite)
    {      
        if(celula != null)
        {
            if(celula.CONTEUDO.Fluxo <= limite)
            {
                MostrarFluxos(celula.ESQUERDO, limite);
            }
            if (celula.CONTEUDO.Fluxo > limite)
            {
                MostrarConteudo(celula);
                percorrerPilha(celula);
                MostrarFluxos(celula.DIREITO, limite);
                MostrarFluxos(celula.ESQUERDO, limite);
            }
        }
    }
}
