Console.WriteLine("===== CAJA REGISTRADORA =====");
Console.WriteLine("1. Calcular cambio en billetes y monedas");
Console.WriteLine("2. Aplicar descuento por tipo de cliente");
Console.WriteLine("3. Validar fecha de entrega");
Console.WriteLine("4. Verificar folio capicúa");
Console.WriteLine("5. Redondear precio y diferencia de inventario");
Console.WriteLine("6. Salir");
Console.WriteLine("Elige una opción:");

int opcion = int.Parse(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.WriteLine("Ingresa el precio:");
        int precio = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa el pago:");
        int pago = int.Parse(Console.ReadLine());

        if (pago < precio)
        {
            int falta = precio - pago;
            Console.WriteLine("Pago insuficiente, faltan $" + falta);
        }
        else if (pago == precio)
        {
            Console.WriteLine("Pago exacto, no hay cambio");
        }
        else
        {
            int cambio = pago - precio;
            Console.WriteLine("Cambio: " + cambio);

            int b200 = cambio / 200;
            cambio = cambio % 200;

            int b100 = cambio / 100;
            cambio = cambio % 100;

            int b50 = cambio / 50;
            cambio = cambio % 50;

            int b20 = cambio / 20;
            cambio = cambio % 20;

            int m10 = cambio / 10;
            cambio = cambio % 10;

            int m5 = cambio / 5;
            cambio = cambio % 5;

            int m2 = cambio / 2;
            cambio = cambio % 2;

            int m1 = cambio;

            if (b200 > 0) Console.WriteLine(b200 + " billete de 200");
            if (b100 > 0) Console.WriteLine(b100 + " billete de 100");
            if (b50 > 0) Console.WriteLine(b50 + " billete de 50");
            if (b20 > 0) Console.WriteLine(b20 + " billete de 20");
            if (m10 > 0) Console.WriteLine(m10 + " moneda de 10");
            if (m5 > 0) Console.WriteLine(m5 + " moneda de 5");
            if (m2 > 0) Console.WriteLine(m2 + " moneda de 2");
            if (m1 > 0) Console.WriteLine(m1 + " moneda de 1");
        }
        break;

    case 2:
        Console.WriteLine("Ingresa el subtotal:");
        double subtotal = double.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa el tipo de cliente (E/D/G):");
        char tipoCliente = char.Parse(Console.ReadLine());
        Console.WriteLine("¿Tiene credencial? (S/N):");
        char credencialInput = char.Parse(Console.ReadLine());
        bool tieneCredencial = (credencialInput == 'S' || credencialInput == 's');

        double porcentajeBase = 0;
        bool tipoValido = true;

        switch (tipoCliente)
        {
            case 'E':
            case 'e':
                porcentajeBase = 0.15;
                break;
            case 'D':
            case 'd':
                porcentajeBase = 0.10;
                break;
            case 'G':
            case 'g':
                porcentajeBase = 0.00;
                break;
            default:
                tipoValido = false;
                break;
        }

        if (!tipoValido)
        {
            Console.WriteLine("Tipo de cliente no válido");
        }
        else
        {
            double porcentajeAdicional = 0;
            bool esDocente = (tipoCliente == 'D' || tipoCliente == 'd');

            if ((subtotal >= 500 && tieneCredencial) || esDocente)
            {
                porcentajeAdicional = 0.05;
            }

            double porcentajeTotal = porcentajeBase + porcentajeAdicional;
            double descuentoTotal = subtotal * porcentajeTotal;
            double totalAPagar = subtotal - descuentoTotal;

            Console.WriteLine("Subtotal: " + subtotal);
            Console.WriteLine("Descuento total: " + descuentoTotal);
            Console.WriteLine("Total a pagar: " + totalAPagar);
        }
        break;

    case 3:
        Console.WriteLine("Ingresa el día:");
        int dia = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa el mes:");
        int mes = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa el año:");
        int anio = int.Parse(Console.ReadLine());

        bool esBisiesto = (anio % 4 == 0 && anio % 100 != 0) || (anio % 400 == 0);

        int diasDelMes = 0;
        switch (mes)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                diasDelMes = 31;
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                diasDelMes = 30;
                break;
            case 2:
                if (esBisiesto)
                {
                    diasDelMes = 29;
                }
                else
                {
                    diasDelMes = 28;
                }
                break;
        }

        if (mes >= 1 && mes <= 12 && dia >= 1 && dia <= diasDelMes)
        {
            if (esBisiesto)
            {
                Console.WriteLine("Fecha válida, año bisiesto");
            }
            else
            {
                Console.WriteLine("Fecha válida, año no bisiesto");
            }
        }
        else
        {
            if (esBisiesto)
            {
                Console.WriteLine("Fecha inválida, año bisiesto");
            }
            else
            {
                Console.WriteLine("Fecha inválida, año no bisiesto");
            }
        }
        break;

    case 4:
        Console.WriteLine("Ingresa un folio de 4 dígitos:");
        int folio = int.Parse(Console.ReadLine());

        if (folio < 1000 || folio > 9999)
        {
            Console.WriteLine("Folio inválido");
        }
        else
        {
            int d1 = folio / 1000;
            int d2 = (folio / 100) % 10;
            int d3 = (folio / 10) % 10;
            int d4 = folio % 10;

            int suma = d1 + d2 + d3 + d4;
            long producto = (long)d1 * d2 * d3 * d4;

            string paridadSuma;
            if (suma % 2 == 0)
            {
                paridadSuma = "par";
            }
            else
            {
                paridadSuma = "impar";
            }

            if (d1 == d4 && d2 == d3)
            {
                Console.WriteLine("Es capicúa, suma = " + suma + " (" + paridadSuma + "), producto = " + producto);
            }
            else
            {
                Console.WriteLine("No es capicúa, suma = " + suma + " (" + paridadSuma + "), producto = " + producto);
            }
        }
        break;

    case 5:
        Console.WriteLine("Ingresa el precio:");
        double precioDouble = double.Parse(Console.ReadLine());

        int precioRedondeado = (int)(precioDouble + 0.5);
        double diferenciaPrecio = precioDouble - precioRedondeado;

        if (diferenciaPrecio < 0)
        {
            diferenciaPrecio = diferenciaPrecio * -1;
        }

        Console.WriteLine("Precio redondeado: " + precioRedondeado);
        Console.WriteLine("Parte decimal descartada o agregada: " + diferenciaPrecio);

        Console.WriteLine("Ingresa las piezas esperadas:");
        int esperadas = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingresa las piezas contadas:");
        int contadas = int.Parse(Console.ReadLine());

        if (contadas == esperadas)
        {
            Console.WriteLine("Inventario correcto");
        }
        else if (contadas < esperadas)
        {
            int faltan = esperadas - contadas;
            Console.WriteLine("Faltan " + faltan + " piezas");
        }
        else
        {
            int meSogran = contadas - esperadas;
            Console.WriteLine("Sobran " + meSogran + " piezas");
        }
        break;

    case 6:
        Console.WriteLine("Gracias por usar la caja registradora");
        break;

    default:
        Console.WriteLine("Opción no válida");
        break;
}
