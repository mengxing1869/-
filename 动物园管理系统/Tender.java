package zoo;

import java.util.ArrayList;
import java.util.Scanner;

public class Tender {

    String no;
    String name;
    int wages;
    ArrayList<Animail> animal=new ArrayList<Animail>();
    public Tender(){

    }
    public Tender(String tender,String name,int wages){
        this.no=tender;
        this.name=name;
        this.wages=wages;
    }

}
