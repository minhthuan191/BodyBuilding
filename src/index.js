import React from 'react';
import ReactDOM from 'react-dom/client';

import './scss/index.scss';

import Layout from './container/Layout'

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
    <Layout />
  </React.StrictMode>
);

