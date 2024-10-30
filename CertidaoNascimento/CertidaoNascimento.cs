using System;

public class Pessoa
{
    public string Nome { get; }
    public CertidaoNascimento Certidao { get; private set; }

    public Pessoa(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome não pode ser vazio ou nulo.");

        Nome = nome;
    }

    public void AdicionarCertidao(CertidaoNascimento certidao)
    {
        if (Certidao != null)
            throw new InvalidOperationException("A pessoa já possui uma certidão.");

        Certidao = certidao ?? throw new ArgumentNullException(nameof(certidao));
    }
}

public class CertidaoNascimento
{
    public DateTime DataEmissao { get; }
    public Pessoa Pessoa { get; }

    public CertidaoNascimento(DateTime dataEmissao, Pessoa pessoa)
    {
        if (pessoa == null)
            throw new ArgumentNullException(nameof(pessoa));

        DataEmissao = dataEmissao;
        Pessoa = pessoa;
        pessoa.AdicionarCertidao(this);
    }
}