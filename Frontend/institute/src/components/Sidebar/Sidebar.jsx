import React from 'react';
import { Link } from 'react-router-dom';

import './style.css';
import Robot from './Picture.png';

const Sidebar = () => (
  <aside className="sidebar">
    <img src={Robot} alt="robot" className="sidebar__image" />
    <Link className="sidebar__link" to="/">
      Главная
    </Link>
    <Link className="sidebar__link" to="/universities">
      ВУЗы
    </Link>
    <Link className="sidebar__link" to="/colleges">
      ССУЗы
    </Link>
  </aside>
);

export default Sidebar;
