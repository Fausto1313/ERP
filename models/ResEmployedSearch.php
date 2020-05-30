<?php

namespace app\models;


use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResEmployed;

class ResEmployedSearch extends ResEmployed
{
    /**
Importamos parte de las reglas del modelo     */
    public function rules()
    {
        return [
            [['Id', 'Id_Comp', 'E_Nomina', 'ID_Partner'], 'integer'],
            [['N_Empleado', 'E_Apellidos', 'F_Creacion'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }
/*
     En este solo se define en que metodo sebuscara si sera por ajax la busquedao por query
  Nota siempre usamos query, cuando sean demasiados registros(millones) es recomendable usar
     * Elastisearch como widget 
     *    */
    public function search($params)
    {
        $query = ResEmployed::find();

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        // definimos las dependencias de busqueda esto nos permitira buscar en simultaneo
        $query->andFilterWhere([
            'Id' => $this->Id,
            'Id_Comp' => $this->Id_Comp,
            'E_Nomina' => $this->E_Nomina,
            'F_Creacion' => $this->F_Creacion,
            'ID_Partner' => $this->ID_Partner,
        ]);

        $query->andFilterWhere(['like', 'N_Empleado', $this->N_Empleado])
            ->andFilterWhere(['like', 'E_Apellidos', $this->E_Apellidos]);

        return $dataProvider;
    }
}
