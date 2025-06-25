using UnityEngine;

public class HabitacionManager : MonoBehaviour
{
    public RoomController[] habitaciones;
    private int habitacionActual = 0;

    void Start()
    {
        if (habitaciones.Length == 0)
        {
            Debug.LogWarning("No hay habitaciones asignadas en HabitacionManager.");
            return;
        }
        habitaciones[habitacionActual].ActivarHabitacion();
    }

    public void CambiarAHabitacion(int nuevaHabitacion)
    {
        if (nuevaHabitacion < 0 || nuevaHabitacion >= habitaciones.Length)
        {
            Debug.LogWarning("Número de habitación inválido: " + nuevaHabitacion);
            return;
        }

        habitaciones[habitacionActual].DesactivarHabitacion();
        habitacionActual = nuevaHabitacion;
        habitaciones[habitacionActual].ActivarHabitacion();

        Debug.Log("Cambiando a habitación: " + habitaciones[habitacionActual].gameObject.name);
    }

    public RoomController GetHabitacionActual()
    {
        return habitaciones[habitacionActual];
    }
}
