
class ITennisPlayer {
    getPlayerInfo() { }
    setPlayerInfo(info) { }
}

class ATPPlayer extends ITennisPlayer {
    constructor() {
        super();
        this.info = '';
    }

    getPlayerInfo() {
        return this.info;
    }

    setPlayerInfo(info) {
        this.info = info;
    }
}

class ProxyTennisPlayer extends ITennisPlayer {
    constructor() {
        super();
        this.atpPlayer = new ATPPlayer();
    }

    getPlayerInfo() {
        return this.atpPlayer.getPlayerInfo();
    }

    setPlayerInfo(info) {
        this.atpPlayer.setPlayerInfo(info);
    }
}

const proxyTennisPlayer = new ProxyTennisPlayer();
proxyTennisPlayer.setPlayerInfo("Ranking up with 20 positions");
console.log(proxyTennisPlayer.getPlayerInfo());
