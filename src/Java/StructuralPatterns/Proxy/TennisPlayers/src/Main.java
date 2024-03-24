interface ITennisPlayer {
    String getPlayerInfo();

    void setPlayerInfo(String info);
}

class ATPPlayer implements ITennisPlayer {
    private String info;

    @Override
    public String getPlayerInfo() {
        return info;
    }

    @Override
    public void setPlayerInfo(String info) {
        this.info = info;
    }
}

class ProxyTennisPlayer implements ITennisPlayer {
    private final ATPPlayer atpPlayer = new ATPPlayer();

    @Override
    public String getPlayerInfo() {
        return atpPlayer.getPlayerInfo();
    }

    @Override
    public void setPlayerInfo(String info) {
        atpPlayer.setPlayerInfo(info);
    }
}

public class Main {
    public static void main(String[] args) {
        ProxyTennisPlayer proxyTennisPlayer = new ProxyTennisPlayer();
        proxyTennisPlayer.setPlayerInfo("Ranking up with 20 positions");

        System.out.println(proxyTennisPlayer.getPlayerInfo());
    }
}