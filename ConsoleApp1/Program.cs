int lotDurationHours = 24;
int lotDuration15MinBlocks = lotDurationHours * 4;

int numberAvailableWorkers = 3;

string?[][] availableWorkers = new string?[numberAvailableWorkers][];

for (int i = 0; i < numberAvailableWorkers; i++)
{
    availableWorkers[i] = new string?[lotDuration15MinBlocks];
}





public class Piece
{
    public string? Name { get; set; }
    public Operation[]? operations { get; set; }
}

public class Operation
{
    public string? Name { get; set; }
    public int Duration { get; set; }
}


/*

- Expected output of the program

=========================================
Distribución de operaciones en maquinaria
=========================================
- SMP41 (eficiencia 92%): 
    [0 - 4 hs][1] Plancha Blanca Op. 030
    [4 - 7 hs][1] Respaldo Blanco Op. 030
    [7 - 8 hs][2] Frente Llaves Blanco Op. 030
    ...
- SMP42 (eficiencia 20%):
    [0 - 2 hs][3] Contrapuerta Parrilla Op. 030
    [2 - 3 hs][3] Frente Chasis Op. 040
    ... 
- SMP 43:
    ...

========================================
Eficiencia operarios
========================================
- Operario 1: 95%
- Operario 2: 100%
- Operario 3: 92%

*/

