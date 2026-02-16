using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace WpfApp1
{
    static internal class Seats
    {
        static List<Seans_Seat> seans_seats = Core.Context.Seans_Seat.ToList();
        static List<Seat> seat = Core.Context.Seat.ToList();
        public static List<Seat> lst_seat;
        public static List<Seans_Seat> lst_seat_seans;
        public static List<Seans_Seat> selected_seats = new List<Seans_Seat>();

        static public void FindSeats(int kinozal_id, int seans_id)
        {
            lst_seat = seat.Where(s => s.Kinozal_ID == kinozal_id).ToList();
            lst_seat_seans = seans_seats.Where(s => s.Seans_ID == seans_id).ToList();
        }

        static public int MaxRow()
        {
            return lst_seat.Max(s => s.Row);
        }

        static public int MaxNum()
        {
            return lst_seat.Max(s => s.Number);
        }

        static public bool isActive(int row, int number)
        {
            try
            {
                Seat sidenie = lst_seat.First(s => s.Number == number && s.Row == row);
                Seans_Seat s_s = seans_seats.First(s => s.Seat == sidenie && s.Seans_ID == SelectedSeans.seansID);
                return s_s.Status;
            }
            catch
            {
                MessageBox.Show("АААААААААААААААААААААААААААААААА ВСЕ СЛОМАЛОСЬ код ошибки: 001");
                return false;
            }
        }

        static public void Add(int row, int number)
        {
            Seat sidenie = lst_seat.First(s => s.Number == number && s.Row == row);
            Seans_Seat s_s = seans_seats.First(s => s.Seat == sidenie && s.Seans_ID == SelectedSeans.seansID);
            selected_seats.Add(s_s);
        }

        static public void Del(int row, int number)
        {
            Seat sidenie = lst_seat.First(s => s.Number == number && s.Row == row);
            Seans_Seat s_s = seans_seats.First(s => s.Seat == sidenie && s.Seans_ID == SelectedSeans.seansID);
            
            selected_seats.Remove(s_s);
        }

        public static bool isTicket()
        {
            return selected_seats.Count != 0;
        }
    }
}
