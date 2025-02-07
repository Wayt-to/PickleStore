using System;
using System.Linq;
using System.Web.Http;
using TursuBankAPI.Models;
namespace TursuBankAPI.API
{
    public class PAYController : ApiController
    {
        TursuBankDBEntities db = new TursuBankDBEntities();
        // GET api/<controller>
        public string Get()
        {
            return "Bilgileriniz Kontrol Ediliyor";
        }

        // GET api/<controller>/5
        public string Get(string kartNO, string ay, string yil, string CVV, double bakiye, string merchantID, string merchantPass)
        {
            int saticisayi = db.SanalPosMusterileri.Count(sm => sm.SaticiKodu == merchantID && sm.SaticiSifre == merchantPass);
            if (saticisayi > 0)
            {
                SanalPosMusterileri spm = db.SanalPosMusterileri.First();
                if (Convert.ToBoolean(spm.Durum))
                {
                    int sayi = db.Kartlar.Count(k => k.KartNo == kartNO);
                    if (sayi > 0)
                    {
                        Kartlar kart = db.Kartlar.First(k => k.KartNo == kartNO);
                        Hesaplar hesap = db.Hesaplar.Find(kart.HesapID);
                        if (kart.CVV == CVV)
                        {
                            DateTime kartsonkullanma = Convert.ToDateTime(DateTime.Now.Month + "/" + ay + "/" + yil);
                            if (kartsonkullanma > DateTime.Now && kart.SonKullanimAy == ay && kart.SonKullanimYil == yil)
                            {
                                if (Convert.ToBoolean(kart.KartDurum))
                                {
                                    if (hesap.Bakiye >= (decimal)bakiye)
                                    {
                                        hesap.Bakiye -= (decimal)bakiye;
                                        db.SaveChanges();
                                        return "201";
                                    }
                                    else
                                    {
                                        return "301";
                                    }
                                }
                                else
                                {
                                    return "401";
                                }
                            }
                            else
                            {
                                return "501";
                            }
                        }
                        else
                        {
                            return "801";
                        }
                    }
                    else
                    {
                        return "901";
                    }
                }
                else
                {
                    return "601";
                }

            }
            else
            {
                return "701";
            }
        }

        // POST api/<controller>
        public void Post()
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}