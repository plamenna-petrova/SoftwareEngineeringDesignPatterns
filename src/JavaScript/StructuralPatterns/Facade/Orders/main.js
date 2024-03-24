
class Order {
    constructor(dishName, dishPrice, user, shippingAddress, shippingPrice) {
        this.dishName = dishName;
        this.dishPrice = dishPrice;
        this.user = user;
        this.shippingAddress = shippingAddress;
        this.shippingPrice = shippingPrice;
    }

    toString() {
        return `User ${this.user} ordered ${this.dishName}. The full price is ${(this.dishPrice + this.shippingPrice).toFixed(2)} dollars.`;
    }
}

class OnlineRestaurant {
    constructor() {
        this.cart = [];
    }

    addOrderToCart(order) {
        this.cart.push(order);
    }

    completeOrders() {
        console.log("Orders completed. Dispatch in progress...");
    }
}

class ShippingService {
    constructor() {
        this.order = null;
    }

    acceptOrder(order) {
        this.order = order;
    }

    calculateShippingExpenses() {
        this.order.shippingPrice = 15.5;
    }

    shipOrder() {
        console.log(this.order.toString());
        console.log(`The order is being shipped to ${this.order.shippingAddress}`);
    }
}

const restaurant = new OnlineRestaurant();
const shippingService = new ShippingService();

const fishAndChipsOrder = new Order("Fish & Chips", 20, "Jane", "Random Street 1");
const sushiOrder = new Order("Sushi Philadelphia", 45, "Ripley", "Alien Street 321");

restaurant.addOrderToCart(fishAndChipsOrder);
restaurant.addOrderToCart(sushiOrder);
restaurant.completeOrders();

shippingService.acceptOrder(fishAndChipsOrder);
shippingService.calculateShippingExpenses();
shippingService.shipOrder();

shippingService.acceptOrder(sushiOrder);
shippingService.calculateShippingExpenses();
shippingService.shipOrder();