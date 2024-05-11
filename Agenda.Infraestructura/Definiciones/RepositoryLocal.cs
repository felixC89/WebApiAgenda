using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.ModelLocal;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infraestructura.Definiciones
{
    public class RepositoryLocal : IRepository
    {
        private readonly AgendaDbContext _db;

        public RepositoryLocal()
        {
            _db = new AgendaDbContext();
            /*_usuario?.Add(new Usuario { Iduser = 1, UserName = "Felix", Password = "12345" });
            _agenda.Add(new Agendum
            {
                IdAgenda = 1,
                Nombre = "Felix Antonio",
                Apellido = "Calderon",
                Nacionalidad = "Nicaraguense",
                Direccion = "leon Nicaragua",
                Telefono = 88349642,
                Correo = "felix.calderon89@hotmail.com",
                FechaNacimiento = "01-01-1000",
                Edad = 04,
                IdUser = 1
            });*/
        }

        public async Task<Response<bool>> AddContactoAgenda(Agendum newContacto)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = true
            };

            try
            {
                _ = await _db.Agenda.AddAsync(newContacto);
                await _db.SaveChangesAsync();


                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }

        }

        public async Task<Response<bool>> DeleteContactoAgenda(int id)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = true
            };

            try
            {
                var contacto = _db.Agenda.Where(a => a.IdAgenda == id).FirstOrDefault();

                if (contacto == null)
                {
                    result.Message = "No se encontro el registro que eliminar.";
                    result.Data = false;

                    return result;
                }

                _ = _db.Agenda.Remove(contacto);
                await _db.SaveChangesAsync();

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }
        }

        public async Task<Response<IEnumerable<Agendum>>> GetAllContactsAgenda(int iduser)
        {
            var result = new Dominio.Utilies.Response<IEnumerable<Agendum>>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = null
            };

            try
            {
                result.Data = await _db.Agenda.Where(a => a.IdUser == iduser).AsNoTracking().ToListAsync();

                if (result.Data == null)
                {
                    result.Message = "No se obtuvieron datos!";
                }

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = null;
                return result;
            }
        }

        public async Task<Response<Agendum>> GetContactoAgendaById(int id)
        {
            var result = new Dominio.Utilies.Response<Agendum>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = null
            };

            try
            {
                result.Data = await _db.Agenda.Where(a => a.IdAgenda == id).AsNoTracking().FirstOrDefaultAsync();

                if (result.Data == null)
                {
                    result.Message = "No se obtuvieron datos!";
                }

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = null;
                return result;
            }
        }

        public async Task<Response<bool>> UpdateContactoAgenda(Agendum newContacto)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = false
            };

            try
            {
                _db.Entry(newContacto).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                result.Data = true;

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }
        }

        public async Task<Response<IEnumerable<Usuario>>> GetAllUsers()
        {
            var result = new Dominio.Utilies.Response<IEnumerable<Usuario>>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = null
            };

            try
            {
                result.Data = await _db.Usuarios.AsNoTracking().ToListAsync();

                if (result.Data == null)
                {
                    result.Message = "No se obtuvieron datos!";
                }

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = null;
                return result;
            }
        }

        public async Task<Response<bool>> DeleteUser(int id)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = true
            };

            try
            {
                var contacto = _db.Usuarios.Where(a => a.Iduser == id).FirstOrDefault();

                if (contacto == null)
                {
                    result.Message = "No se encontro el registro que eliminar.";
                    result.Data = false;

                    return result;
                }

                _ = _db.Usuarios.Remove(contacto);
                await _db.SaveChangesAsync();

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }
        }

        public async Task<Response<bool>> AddUser(Usuario newUser)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = true
            };

            try
            {
                _ = await _db.Usuarios.AddAsync(newUser);
                await _db.SaveChangesAsync();

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }
        }

        public async Task<Response<Usuario>> GetUserById(int id)
        {
            var result = new Dominio.Utilies.Response<Usuario>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = null
            };

            try
            {
                result.Data = await _db.Usuarios.Where(a => a.Iduser == id).AsNoTracking().FirstOrDefaultAsync();

                if (result.Data == null)
                {
                    result.Message = "No se obtuvieron datos!";
                }

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = null;
                return result;
            }
        }

        public async Task<Response<bool>> UpdateUser(Usuario newUser)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = false
            };

            try
            {
                _db.Entry(newUser).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                result.Data = true;

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }
        }

        public async Task<Response<bool>> isUserValid(Usuario User)
        {
            var result = new Dominio.Utilies.Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = "Operación realizada con exito!",
                Data = true
            };

            try
            {
                var contacto = await _db.Usuarios.Where(a => a.Username == User.Username && a.Password == User.Password).FirstOrDefaultAsync();

                if (contacto == null)
                {
                    result.Message = "No se encontro el registro.";
                    result.Data = false;

                    return result;
                }

                return result;

            }
            catch (Exception ex)
            {
                result.IsSuccessfullRequest = false;
                result.Message = $"Ocurrió un error con aws al realizar la operación:{ex.Message}";
                result.Data = false;
                return result;
            }
        }
    }
}
