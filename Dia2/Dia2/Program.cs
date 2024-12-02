using System.Runtime.CompilerServices;

string rutaInput = "F:/Codigo/CodigoDeAdvientoPorquePolvoronesNoMeHacenFalta/Dia2/Dia2/input.txt";
int validReports = 0;

foreach(string linea in File.ReadLines(rutaInput)){

    
    bool dampenerUsado = false;
    bool reporteValido = true;

    string[] levelsSplitted = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries); 
    int[] levels = Array.ConvertAll(levelsSplitted,int.Parse);

    for(int i = 1; i < levels.Length; i++){

        bool creciente = levels[i] > levels[i-1];
        bool decreciente = levels[i] < levels[i-1];
        bool incrementoValido = CalcularIncrementoValido(levels[i-1], levels[i]);

        if(!incrementoValido || (!creciente && !decreciente)){
           
           if(dampenerUsado){
                reporteValido = false;
                break;  
           }

            dampenerUsado = true;
            reporteValido = false;

                
            // Intentar omitir cada nivel una vez
            for (int indiceIgnorado = 0; indiceIgnorado < levels.Length; indiceIgnorado++)
            {
                //Pido perdón
                if (EsValidoConDampener(levels, indiceIgnorado))
                {
                    reporteValido = true;
                    break;
                }
            }

            if (!reporteValido) break; 
            
        }
    }

    if(reporteValido ){
            validReports ++;
    }

}
//Funcion que reevalua el array pero la posicion ignorar no se evalua 
static bool EsValidoConDampener(int[] levels, int ignorar)
{
    bool creciente = true;
    bool decreciente = true;
    int indiceAnterior = -1;

    for (int i = 0; i < levels.Length; i++)
    {
        // Ignorar índice actual
        if (i == ignorar){
            continue; 
        } 

        if(indiceAnterior != -1){
            bool incrementoValido = CalcularIncrementoValido(levels[indiceAnterior], levels[i]);
            if (!incrementoValido){
                return false;
            }
            if (levels[i] < levels[indiceAnterior]){
                creciente = false;
            }
                
            if (levels[i] > levels[indiceAnterior]){
                decreciente = false;
            }
        }

        indiceAnterior = i;
        
    }

    return creciente || decreciente;
}
static bool CalcularIncrementoValido(int anterior, int actual){

    if(Math.Abs(anterior - actual) == 0 || Math.Abs(anterior - actual) > 3){
        return false;
    }
    return true;
}

Console.WriteLine($"Deberían ser {validReports} reports validos.");


