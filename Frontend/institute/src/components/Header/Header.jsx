import cn from 'classnames';
import React from 'react';

import './style.css';

const Header = ({ className, children }) => {
  return <header className={cn('header', className)}>{children}</header>;
};

export default Header;
