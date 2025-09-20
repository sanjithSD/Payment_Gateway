import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import './App.css';
import Sidebar from './Components/Sidebar';
import Products from './Components/Products';
import DashboardPage from './Components/Dashboard';
import { Routes, Route } from 'react-router-dom';

function App() {
  return (
    <div className="d-flex">
      <Sidebar />
      <div className="flex-grow-1 p-4" style={{ marginLeft: '200px' }}>
        <Routes>
          <Route path="/" element={<DashboardPage />} />
          <Route path="/products" element={<Products />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
