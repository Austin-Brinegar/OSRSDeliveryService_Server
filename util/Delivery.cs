using System;
using System.Text;

namespace OSRSEats.util;

public class Delivery {

    public Guid id {get;}
    public string Name {get;}
    public string Location {get; set;}
    public string Items{get;}

    public Delivery(string name, string location, string items) {
        this.id = Guid.NewGuid();
        this.Name = name;
        this.Location = location;
        this.Items = items;
    }

    public string toString() {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.id + "\n");
        sb.Append(this.Name + "\n");
        sb.Append(this.Location + "\n");
        sb.Append(this.Items);
        return sb.ToString();
    }
}