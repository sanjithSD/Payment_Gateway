import { Link } from 'react-router-dom';

function Sidebar() {
  return (
    <div className="sidebar bg-dark text-white position-fixed vh-100" style={{ width: '200px' }}>
      <div className="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2">
        <Link
          to="/"
          className="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none"
        >
          <span className="fs-5 d-none d-sm-inline">Shoppiee</span>
        </Link>

        <ul className="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start">
          <li className="nav-item">
            <Link
              to="/"
              className="nav-link align-middle px-0 text-white"
            >
              <i className="fs-4 bi-bar-chart-line"></i>
              <span className="ms-1 d-none d-sm-inline">Dashboard</span>
            </Link>
          </li>

          <li className="nav-item">
            <Link
              to="/products"
              className="nav-link align-middle px-0 text-white"
            >
              <i className="fs-4 bi-box-seam"></i>
              <span className="ms-1 d-none d-sm-inline">Products</span>
            </Link>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default Sidebar;
