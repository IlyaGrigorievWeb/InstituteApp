import React from 'react';
import { Link } from 'react-router-dom';

import './style.css';
import Robot from './Robot.png';
import Main from '../../components/Main';
import Header from '../../components/Header';

const Start = () => {
  return (
    <>
      <Header className="header">
        Приветствуем тебя, друг! Ты заканчиваешь 9 или 11 класс и не знаешь куда
        поступить? Мы поможем тебе выбрать! Но сначала ответь на вопрос:
      </Header>
      <Main>
        <div className="main__container">
          <div className="main__who">Ты кто?</div>
          <img src={Robot} alt="robot" />
          <div className="main__variants">
            <div className="main__variant">
              <Link to="/universities" className="main__variant-title">
                11-классник
              </Link>
            </div>
            <div className="main__variant">
              <Link to="/colleges" className="main__variant-title">
                9-классник
              </Link>
            </div>
            <div className="main__variant">
              <div className="main__variant-content">
                (Хочу больше узнать о ВУЗах в нашем городе и знаю список
                экзаменов, которые собираюсь сдавать!)
              </div>
            </div>
            <div className="main__variant">
              <div className="main__variant-content">
                (Хочу больше узнать о ССУЗах в нашем городе и знаю направление,
                по которому хочу учиться!)
              </div>
            </div>
          </div>
        </div>
      </Main>
    </>
  );
};

export default Start;
