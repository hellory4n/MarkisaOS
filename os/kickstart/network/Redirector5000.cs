using System.Collections.Generic;

namespace markisa.network
{

public class Redirector5000
{
    public static Dictionary<string, string> Stuff { get; set; } = new Dictionary<string, string> {
        {"markisaos.com", "markisa.passionfruit.com"},
        {"markisa.com", "markisa.passionfruit.com"},
        {"negócios.passionfruit.com", "business.passionfruit.com"},
        {"negocios.passionfruit.com", "business.passionfruit.com"},
        {"desenvolvedores.passionfruit.com", "developers.passionfruit.com"},
        {"developer.passionfruit.com", "developers.passionfruit.com"},
        {"desenvolvedor.passionfruit.com", "developers.passionfruit.com"},
        {"desenvolvimento.passionfruit.com", "developers.passionfruit.com"},
        {"exemplo.com", "example.com"},
        {"governo.org", "government.org"},
        {"rodrigobiffé.com", "rosstibeeth.com"},
        {"rodrigobiffe.com", "rosstibeeth.com"},
    };
}

}