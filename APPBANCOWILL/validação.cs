public static class Validador
{
    public static bool CPFValido(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        return cpf.All(char.IsDigit);
    }

    public static bool SenhaValida(string senha)
    {
        return senha.Length == 8 && senha.All(char.IsDigit);
    }
}
