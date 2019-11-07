using System;

class Pilha
{
    private FluxoVeiculos conteudo;
    private Pilha proximo;
    private Pilha PRIMEIRO = null;

    public Pilha()
    {

    }
    public Pilha(FluxoVeiculos conteudo,Pilha proximo)
    {
        this.conteudo = conteudo;
        this.proximo = proximo;
    }
    public void Push(FluxoVeiculos e)
    {
        PRIMEIRO = new Pilha(e, PRIMEIRO);
    }
    public void MOSTRAR_ELEMENTOS_PILHA()
    {
        Pilha P = PRIMEIRO;
        while(P != null)
        {
            Console.WriteLine("   |---> Setor:{0} Data:{1} Fluxo:{2}", P.conteudo.Setor,P.conteudo.Data,P.conteudo.Fluxo);
            P = P.proximo;
        }
    }
}