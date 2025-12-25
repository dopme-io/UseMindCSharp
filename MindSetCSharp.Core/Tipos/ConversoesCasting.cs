namespace MindSetCSharp.Core.Tipos;

/// <summary>
/// Demonstra conversões entre tipos (casting)
/// </summary>
public static class ConversoesTipos
{
    public static void DemonstrarConversoes()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║            CONVERSÕES DE TIPOS (CASTING)             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        // ===== CONVERSÃO IMPLÍCITA =====
        Console.WriteLine("✅ CONVERSÃO IMPLÍCITA (Automática - Sem Perda de Dados):\n");
        
        int inteiro = 42;
        long inteiroLongo = inteiro;        // int → long (OK)
        float pontoFlutuante = inteiro;     // int → float (OK)
        double doublePrecisao = inteiro;    // int → double (OK)
        
        Console.WriteLine($"int → long:   {inteiro} → {inteiroLongo}");
        Console.WriteLine($"int → float:  {inteiro} → {pontoFlutuante}");
        Console.WriteLine($"int → double: {inteiro} → {doublePrecisao}");
        
        Console.WriteLine("\n📊 Hierarquia de conversão implícita:");
        Console.WriteLine("   byte → short → int → long → float → double → decimal");

        // ===== CONVERSÃO EXPLÍCITA (CAST) =====
        Console.WriteLine("\n\n⚠️  CONVERSÃO EXPLÍCITA (Manual - Pode Haver Perda):\n");
        
        double numeroDouble = 123.456;
        int numeroInt = (int)numeroDouble;  // Cast explícito - perde decimal
        
        Console.WriteLine($"double → int:  {numeroDouble} → {numeroInt}  (perdeu parte decimal!)");
        
        long numeroGrande = 1234567890L;
        int numeroMenor = (int)numeroGrande; // OK se caber
        
        Console.WriteLine($"long → int:    {numeroGrande} → {numeroMenor}");
        
        // Overflow
        Console.WriteLine("\n⚠️  CUIDADO COM OVERFLOW:\n");
        
        int numeroMuitoGrande = 2_147_483_647; // Max int
        byte numeroPequeno = (byte)numeroMuitoGrande; // Overflow!
        
        Console.WriteLine($"int.MaxValue:  {numeroMuitoGrande}");
        Console.WriteLine($"(byte) cast:   {numeroPequeno}  ❌ Overflow! (esperado: 255, resultado incorreto)");

        // ===== CONVERSÃO COM MÉTODOS =====
        Console.WriteLine("\n\n🔧 CONVERSÃO COM MÉTODOS:\n");
        
        // ToString() - qualquer tipo para string
        int numero = 42;
        string textoNumero = numero.ToString();
        Console.WriteLine($"int.ToString():     {numero} → \"{textoNumero}\"");
        
        // Parse - string para tipo
        string textoInt = "123";
        int numeroParsed = int.Parse(textoInt);
        Console.WriteLine($"int.Parse():        \"{textoInt}\" → {numeroParsed}");
        
        // TryParse - conversão segura
        string textoValido = "456";
        string textoInvalido = "abc";
        
        bool sucesso1 = int.TryParse(textoValido, out int resultado1);
        bool sucesso2 = int.TryParse(textoInvalido, out int resultado2);
        
        Console.WriteLine($"int.TryParse(\"{textoValido}\"):  {sucesso1} → {resultado1}  ✅");
        Console.WriteLine($"int.TryParse(\"{textoInvalido}\"): {sucesso2} → {resultado2}  ❌ Não lança exceção!");
        
        // Convert
        string texto = "789";
        int numeroConvert = Convert.ToInt32(texto);
        double numeroDouble2 = Convert.ToDouble("3.14");
        bool booleano = Convert.ToBoolean("true");
        
        Console.WriteLine($"Convert.ToInt32():  \"{texto}\" → {numeroConvert}");
        Console.WriteLine($"Convert.ToDouble(): \"3.14\" → {numeroDouble2}");
        Console.WriteLine($"Convert.ToBoolean(): \"true\" → {booleano}");

        // ===== BOXING E UNBOXING =====
        Console.WriteLine("\n\n📦 BOXING E UNBOXING:\n");
        
        // Boxing - tipo de valor → object (referência)
        int valorInt = 123;
        object objetoBoxed = valorInt;  // Boxing (copia para heap)
        
        Console.WriteLine($"BOXING:   int {valorInt} → object (armazenado na heap)");
        Console.WriteLine($"          Tipo do object: {objetoBoxed.GetType().Name}");
        
        // Unboxing - object → tipo de valor
        object objetoComInt = 456;
        int valorUnboxed = (int)objetoComInt;  // Unboxing (copia para stack)
        
        Console.WriteLine($"\nUNBOXING: object → int {valorUnboxed}");
        
        Console.WriteLine("\n⚠️  Boxing/Unboxing têm custo de performance!");
        Console.WriteLine("    Use genéricos quando possível: List<int> em vez de ArrayList");

        // ===== CONVERSÃO DE TIPOS PERSONALIZADOS =====
        Console.WriteLine("\n\n🎨 CONVERSÃO PERSONALIZADA:\n");
        
        var temperatura1 = new Celsius(25);
        Fahrenheit temperatura2 = (Fahrenheit)temperatura1;  // Conversão explícita
        
        Console.WriteLine($"Celsius:    {temperatura1.Valor}°C");
        Console.WriteLine($"Fahrenheit: {temperatura2.Valor}°F");
        
        Celsius temperatura3 = (Celsius)temperatura2;  // Volta para Celsius
        Console.WriteLine($"De volta:   {temperatura3.Valor}°C");
    }

    /// <summary>
    /// Exemplo de conversão personalizada com operadores
    /// </summary>
    public class Celsius
    {
        public double Valor { get; set; }

        public Celsius(double valor)
        {
            Valor = valor;
        }

        // Operador de conversão explícita para Fahrenheit
        public static explicit operator Fahrenheit(Celsius c)
        {
            return new Fahrenheit(c.Valor * 9 / 5 + 32);
        }

        // Operador de conversão implícita de double
        public static implicit operator Celsius(double valor)
        {
            return new Celsius(valor);
        }
    }

    public class Fahrenheit
    {
        public double Valor { get; set; }

        public Fahrenheit(double valor)
        {
            Valor = valor;
        }

        // Operador de conversão explícita para Celsius
        public static explicit operator Celsius(Fahrenheit f)
        {
            return new Celsius((f.Valor - 32) * 5 / 9);
        }
    }
}

/// <summary>
/// Demonstra tipo dynamic e suas características
/// </summary>
public static class TipoDynamic
{
    public static void DemonstrarDynamic()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║                 TIPO DYNAMIC                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

        Console.WriteLine("⚡ DYNAMIC - Tipo determinado em RUNTIME:\n");
        
        dynamic variavel = 42;
        Console.WriteLine($"variavel = {variavel} (tipo: {((object)variavel).GetType().Name})");
        
        variavel = "agora é uma string";
        Console.WriteLine($"variavel = \"{variavel}\" (tipo: {((object)variavel).GetType().Name})");
        
        variavel = 3.14;
        Console.WriteLine($"variavel = {variavel} (tipo: {((object)variavel).GetType().Name})");
        
        variavel = true;
        Console.WriteLine($"variavel = {variavel} (tipo: {((object)variavel).GetType().Name})");

        Console.WriteLine("\n\n🔍 OPERAÇÕES COM DYNAMIC:\n");
        
        dynamic x = 10;
        dynamic y = 20;
        dynamic resultado = x + y;
        
        Console.WriteLine($"{x} + {y} = {resultado}");
        
        // Muda para string
        x = "Olá, ";
        y = "Mundo!";
        resultado = x + y;
        
        Console.WriteLine($"\"{x}\" + \"{y}\" = \"{resultado}\"");

        Console.WriteLine("\n\n⚠️  CUIDADOS COM DYNAMIC:\n");
        Console.WriteLine("✅ VANTAGENS:");
        Console.WriteLine("   • Flexibilidade máxima");
        Console.WriteLine("   • Útil para interop COM, JSON dinâmico");
        Console.WriteLine("   • Simplicidade em alguns cenários");
        
        Console.WriteLine("\n❌ DESVANTAGENS:");
        Console.WriteLine("   • SEM verificação em tempo de compilação");
        Console.WriteLine("   • Erros só aparecem em runtime");
        Console.WriteLine("   • Sem IntelliSense");
        Console.WriteLine("   • Performance menor");
        Console.WriteLine("   • Dificulta refatoração");
        
        Console.WriteLine("\n💡 REGRA: Use dynamic apenas quando realmente necessário!");

        // Exemplo de erro em runtime
        Console.WriteLine("\n\n🚨 EXEMPLO DE ERRO EM RUNTIME:\n");
        try
        {
            dynamic texto = "abc";
            dynamic numero = texto + 10; // OK em compilação
            Console.WriteLine(numero);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro: {ex.GetType().Name}");
            Console.WriteLine($"   Mensagem: Operação não suportada detectada apenas em runtime!");
        }
    }
}
