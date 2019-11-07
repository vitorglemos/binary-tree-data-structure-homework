class FluxoVeiculos
{
    private int setor;
    private int data;
    private int fluxo;

    public FluxoVeiculos()
    {

    }
    public FluxoVeiculos(int setor,int data,int fluxo)
    {
        this.setor = setor;
        this.data = data;
        this.fluxo = fluxo;
    }
    public int Setor
    {
        get { return setor; }
        set { setor = value; }
    }
    public int Data
    {
        get { return data; }
        set { data = value; }
    }
    public int Fluxo
    {
        get { return fluxo; }
        set { fluxo = value; }
    }
}