import axios from 'axios';
import React from 'react';
import { useParams } from 'react-router-dom';

import './style.css';
import Header from '../../components/Header';
import Main from '../../components/Main';
import { INSTITUTES } from '../../utils/api';
import { SUBJECTS, TYPES } from '../../utils/constants';

const Institute = () => {
  const { instituteId } = useParams();
  const [institute, setInstitute] = React.useState({});

  const fetchData = async () => {
    const { data } = await axios.get(`${INSTITUTES}/${instituteId}`);
    setInstitute(data);
  };

  React.useEffect(() => {
    fetchData();
  }, []);

  const INST = {
    id: 0,
    name:
      'Автономная некоммерческая организация высшего образования Московский гуманитарно-экономический университет Калужский институт (филиал)',
    specialties: [
      {
        id: 0,
        directionCode: '54.03.01',
        name: 'Дизайн (Дизайн среды)',
        admissionSubjects: [0, 1, 2, 3]
      },
      {
        id: 0,
        directionCode: '54.03.01',
        name: 'Дизайн (Дизайн среды)',
        admissionSubjects: [0, 1, 2, 3]
      },
      {
        id: 0,
        directionCode: '54.03.01',
        name: 'Дизайн (Дизайн среды)',
        admissionSubjects: [0, 1, 2, 3]
      }
    ],

    address: 'Калуга',
    url: ' htpp nidskds',
    director: ' kjdsjksfdkdfk',
    phone: ' kjsfkjdfkj'
  };

  return (
    <>
      <Header>{institute.name}</Header>
      <Main>
        <h3>Направления подготовки</h3>
        <div className="institute__main-container">
          <div className="institute__directions">
            {(institute.specialties || []).map(specialty => (
              <React.Fragment key={specialty.id}>
                <div className="institute-direction__column">
                  {specialty.directionCode}
                </div>
                <div className="institute-direction__column">
                  {specialty.name}
                </div>
                {institute.type === TYPES.university.id && (
                  <div className="institute-direction__column">
                    {(specialty.admissionSubjects || []).map(subjectId => (
                      <div>
                        {
                          SUBJECTS.find(subject => subject.id === subjectId)
                            .label
                        }
                      </div>
                    ))}
                  </div>
                )}
                <div className="institute-direction__column">очная</div>
              </React.Fragment>
            ))}
          </div>
          <div>
            <div>{institute.address}</div>
            <div>{institute.url}</div>
            <div>{institute.director}</div>
            <div>{institute.phone}</div>
          </div>
        </div>
      </Main>
    </>
  );
};

export default Institute;
