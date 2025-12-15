import { useState } from 'react';

const FavouritesPage = () => {
  const [favourites] = useState([
    {
      id: 1,
      name: 'Pizza Palace',
      cuisine: 'Italian, Pizza',
      rating: 4.5,
      deliveryTime: '25-30 mins',
      image: '/images/pizza.png'
    },
    {
      id: 2,
      name: 'Burger King',
      cuisine: 'Burgers, Fast Food',
      rating: 4.2,
      deliveryTime: '20-25 mins',
      image: '/images/burger.png'
    },
    {
      id: 3,
      name: 'Subway',
      cuisine: 'Healthy, Sandwiches',
      rating: 4.3,
      deliveryTime: '15-20 mins',
      image: '/images/subway.png'
    }
  ]);

  return (
    <div className="w-full p-8 font-outfit">
      <h2 className="text-3xl font-bold text-gray-900 mb-8">Your Favourites</h2>
      
      {favourites.length === 0 ? (
        <div className="bg-white rounded-xl shadow-md border border-gray-200 p-12 text-center">
          <div className="text-6xl mb-4">❤️</div>
          <h3 className="text-xl font-semibold text-gray-900 mb-2">No favourites yet</h3>
          <p className="text-gray-500">Start adding restaurants to your favourites!</p>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          {favourites.map(restaurant => (
            <div key={restaurant.id} className="bg-white rounded-xl shadow-md border border-gray-200 p-6 hover:shadow-lg transition-shadow">
              <div className="flex gap-4">
                <img 
                  src={restaurant.image} 
                  alt={restaurant.name}
                  className="w-20 h-20 rounded-lg object-cover"
                  onError={(e) => {
                    e.target.src = 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iODAiIGhlaWdodD0iODAiIHZpZXdCb3g9IjAgMCA4MCA4MCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHJlY3Qgd2lkdGg9IjgwIiBoZWlnaHQ9IjgwIiBmaWxsPSIjRjVGNUY1Ii8+CjxwYXRoIGQ9Ik0yNSAyNUg1NVY1NUgyNVYyNVoiIGZpbGw9IiNEREREREQiLz4KPC9zdmc+';
                  }}
                />
                <div className="flex-1">
                  <div className="flex justify-between items-start mb-2">
                    <h3 className="font-bold text-gray-900 text-lg">{restaurant.name}</h3>
                    <button className="text-red-500 hover:text-red-700 text-xl">
                      ❤️
                    </button>
                  </div>
                  <p className="text-gray-600 text-sm mb-2">{restaurant.cuisine}</p>
                  <div className="flex items-center gap-4 text-sm">
                    <span className="flex items-center gap-1">
                      <span className="text-green-600">⭐</span>
                      <span className="font-medium">{restaurant.rating}</span>
                    </span>
                    <span className="text-gray-600">{restaurant.deliveryTime}</span>
                  </div>
                  <button className="page-btn page-btn-primary mt-3">
                    Order Now
                  </button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default FavouritesPage;