using System;

// Estadísticas iniciales
int VidaJugador = 10;
int VidaEnemigo = 2;
int AtaqueJugador = 30;
int AtaqueEnemigo = 5;
int DefensaJugador = 5;
int DefensaEnemigo = 6;
string input = " ";
Random random = new Random();

// Función para mostrar las estadísticas del jugador y el enemigo
void MostrarEstadisticas()
{
    Console.WriteLine("\n=== ESTADÍSTICAS ===");
    Console.WriteLine($"Jugador - Vida: {VidaJugador}, Defensa: {DefensaJugador}, Ataque: {AtaqueJugador}");
    Console.WriteLine($"Enemigo - Vida: {VidaEnemigo}, Defensa: {DefensaEnemigo}, Ataque: {AtaqueEnemigo}");
    Console.WriteLine("=====================\n");
}

// Bucle de combate
while (VidaJugador > 0 && VidaEnemigo > 0)
{
    // Muestra las estadísticas antes de la acción
    MostrarEstadisticas();

    // Turno del jugador
    Console.WriteLine("El enemigo está a punto de atacar, ¿qué desea hacer?");
    Console.WriteLine("[1] Atacar");
    Console.WriteLine("[2] Defenderse");
    Console.WriteLine("[3] Esquivar");
    input = Console.ReadLine();
    Console.Clear();

    // Acción del jugador
    switch (input)
    {
        case "1":
            Console.WriteLine("El jugador atacó");
            int danoAlEnemigo = Math.Max(0, AtaqueJugador - DefensaEnemigo); // Asegura que no haya daño negativo
            VidaEnemigo -= danoAlEnemigo;
            Console.WriteLine($"El jugador hizo {danoAlEnemigo} puntos de daño al enemigo.");
            Console.WriteLine("La vida actual del enemigo es de " + VidaEnemigo + " puntos");
            break;
        case "2":
            Console.WriteLine("El jugador se defendió");
            DefensaJugador += 3; // Aumenta temporalmente la defensa
            Console.WriteLine("La defensa actual del jugador es de " + DefensaJugador);
            break;
        case "3":
            int chanceEsquivar = random.Next(0, 100);
            if (chanceEsquivar > 40)
            {
                Console.WriteLine("El jugador esquivó con éxito");
            }
            else
            {
                Console.WriteLine("El jugador falló en esquivar");
            }
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }

    // Si el enemigo sigue vivo, turno del enemigo
    if (VidaEnemigo > 0)
    {
        Console.WriteLine("\n----------------------");
        Console.WriteLine("Turno del enemigo");
        Console.WriteLine("----------------------");

        // Muestra las estadísticas de nuevo antes de la acción del enemigo
        MostrarEstadisticas();

        int opcionEnemigo = random.Next(1, 4); // Genera una opción aleatoria para el enemigo (1, 2 o 3)

        // Acción del enemigo
        switch (opcionEnemigo)
        {
            case 1:
                Console.WriteLine("El enemigo atacó al jugador");
                int danoAlJugador = Math.Max(0, AtaqueEnemigo - DefensaJugador); // Asegura que no haya daño negativo
                VidaJugador -= danoAlJugador;
                Console.WriteLine($"El enemigo hizo {danoAlJugador} puntos de daño al jugador.");
                Console.WriteLine("La vida del jugador es de: " + VidaJugador);
                break;
            case 2:
                Console.WriteLine("El enemigo se defendió");
                DefensaEnemigo += 3; // Aumenta temporalmente la defensa
                Console.WriteLine("La defensa del enemigo es de " + DefensaEnemigo);
                break;
            case 3:
                int chanceEsquivarEnemigo = random.Next(0, 100);
                if (chanceEsquivarEnemigo > 40)
                {
                    Console.WriteLine("El enemigo esquivó con éxito");
                }
                else
                {
                    Console.WriteLine("El enemigo falló en esquivar");
                }
                break;
        }
    }

    Console.WriteLine("\n----------------------");
}

// Verifica quién ganó
if (VidaJugador <= 0)
{
    Console.WriteLine("¡El jugador ha sido derrotado!");
}
else if (VidaEnemigo <= 0)
{
    Console.WriteLine("¡El enemigo ha sido derrotado!");
}
