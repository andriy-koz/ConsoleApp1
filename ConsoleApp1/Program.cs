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
Piece LateralHorno = new()
{
    Name = "Lateral Horno",
    Operations = [LHOp30, LHOp40, LHOp50]
};

List<Piece> PieceList = new() { PlanchaBlanca, RespaldoBlanco, FrenteLlaves };
List<Machine> MachineList = new() { Smp41, Smp42, Smp43 };

foreach (var piece in PieceList)
{
    for (int i = 0; i < piece.Operations?.Length; i++)
    {
        int availableStartTime = 0;
        string? availableMachine = null;
        int availableWorker = 0;
        int preOperationFinishTime = piece.Operations[i].HasPreOperations ? piece.Operations[i - 1].EndTime : 0; 
        // Check for an available machine time block 
        foreach (var machine in MachineList)
        {
            int machineAvailableStartTime = 0;
            string? machineAvailableName = null;
            
            for (int j = preOperationFinishTime; j < machine.AvailableTime?.Length; j++)
            {
                for (int k = 0; k < piece.Operations[i].Duration;  k++)
                {
                    if (machine.AvailableTime[j] != null)
                        break;
                    if (k == piece.Operations[i].Duration - 1)
                    {
                        if (j <= machineAvailableStartTime)
                        { 
                            machineAvailableStartTime = j;
                            machineAvailableName = machine.Name;
                        }
                    } 
                }

                for (int m = 0; m < availableWorkers.Length; m++ )
                {
                    for (int l = 0; l < availableWorkers[m].Length; l++)
                    {
                        for (int o = 0; o < piece.Operations[i].Duration; o++)
                        {
                            if (availableWorkers[m][o] != null)
                                break;
                            if (o == piece.Operations[i].Duration - 1)
                            {
                                if (l == machineAvailableStartTime)
                                {
                                    availableWorker = m;
                                    availableStartTime = l;
                                    availableMachine = machineAvailableName;
                                    piece.Operations[i].StartTime = availableStartTime;
                                    piece.Operations[i].EndTime = availableStartTime + piece.Operations[i].Duration;
                                }
                            } 

                        }
                    }
                }
            }
        }
        Console.WriteLine("=====");
        Console.WriteLine($"Pieza: {piece.Name}");
        Console.WriteLine($"Operación: {i}");
        Console.WriteLine($"Maquina: {availableMachine}");
        Console.WriteLine($"Operario: {availableWorker}");
        Console.WriteLine($"Hora inicio: {piece.Operations[i].StartTime}");
        Console.WriteLine($"Hora fin: {piece.Operations[i].EndTime}");
        Console.WriteLine("=====");
        // Check for an available worker time block
        // Assign operation
    }
}

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
    public int StartTime = 0;
    public int EndTime = 0;
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

