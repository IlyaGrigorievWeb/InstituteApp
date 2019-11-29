import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Sidebar from '../../components/Sidebar';
import Start from '../Start';
import InstitutesList from '../InstitutesList';
import Institute from '../Institute/Institute';

const Index = () => {
  return (
    <>
      <Sidebar />
      <Switch>
        <Route exact path="/" component={Start} />
        <Route
          path="/universities"
          render={() => <InstitutesList headerTitle="ВУЗы Калужской области" />}
        />
        <Route
          path="/colleges"
          render={() => (
            <InstitutesList headerTitle="ССУЗы Калужской области" />
          )}
        />
        <Route path="/institutes/:instituteId" component={Institute} />
      </Switch>
    </>
  );
};

export default Index;
