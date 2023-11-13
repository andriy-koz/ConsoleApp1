int lotDurationHours = 24;
int lotDuration15MinBlocks = lotDurationHours * 4;

int numberAvailableWorkers = 3;

// Init workers and their available time
string?[][] availableWorkers = new string?[numberAvailableWorkers][];

for (int i = 0; i < numberAvailableWorkers; i++)
{
    availableWorkers[i] = new string?[lotDuration15MinBlocks];
}

// Init machines and their available time
Machine Smp41 = new()
{ Name = "SMP41", AvailableTime = new string[lotDuration15MinBlocks] };

Machine Smp42 = new()
{ Name = "SMP42", AvailableTime = new string[lotDuration15MinBlocks] };

Machine Smp43 = new()
{ Name = "SMP43", AvailableTime = new string[lotDuration15MinBlocks] };

// Init pieces and operations

// Plancha Blanca
Operation? PBOp30 = new() { Number = 3, Duration = 12, HasPreOperations = false, HasPostOperations = false };
Piece PlanchaBlanca = new()
{
    Name = "Plancha Blanca",
    Operations = [PBOp30]
};

// Respaldo Blanco
Operation? RBOp30 = new() { Number = 3, Duration = 10, HasPreOperations = false, HasPostOperations = true };
Operation? RBOp40 = new() { Number = 4, Duration = 12, HasPreOperations = true, HasPostOperations = false };
Piece RespaldoBlanco = new()
{
    Name = "Respaldo Blanco",
    Operations = [RBOp30, RBOp40]
};

// Frente Llaves
Operation? FLOp30 = new() { Number = 3, Duration = 8, HasPreOperations = false, HasPostOperations = true };
Operation? FLOp40 = new() { Number = 4, Duration = 4, HasPreOperations = true, HasPostOperations = true };
Operation? FLOp50 = new() { Number = 5, Duration = 10, HasPreOperations = true, HasPostOperations = false };
Piece FrenteLlaves = new()
{
    Name = "Frente Llaves",
    Operations = [FLOp30, FLOp40, FLOp50]
};

// Lateral Horno
Operation? LHOp30 = new() { Number = 3, Duration = 10, HasPreOperations = false, HasPostOperations = true };
Operation? LHOp40 = new() { Number = 4, Duration = 12, HasPreOperations = true, HasPostOperations = true };
Operation? LHOp50 = new() { Number = 5, Duration = 7, HasPreOperations = true, HasPostOperations = false };



public class Machine
{
    public string? Name;
    public string[]? AvailableTime;
}

public class Piece
{
    public string? Name { get; set; }
    public Operation[]? Operations { get; set; }
}

public class Operation
{
    public int Number { get; set; }
    public int Duration { get; set; }
    public bool HasPreOperations { get; set; }
    public bool HasPostOperations { get; set; }
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

