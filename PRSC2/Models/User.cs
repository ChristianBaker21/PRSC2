using PRSC2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRSC2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(12)]
        public string Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

        public User()
        {
            {

                var _context = new PRSC2Context();

                var ReqCtrl = new UsersController(_context);
                var updTotal = ReqCtrl.RecalculateRequestTotal(1);
                var req1 = _context.Request.Find(2);
                ReqCtrl.ReviewRrequest(req1);

                var isWorked = ReqCtrl.SetToRejected(req1);

                var UserCtrl = new Controllers.UsersController(_context);
                var user = UserCtrl.Login("xx", "yy");
            }

            }
        }
}
