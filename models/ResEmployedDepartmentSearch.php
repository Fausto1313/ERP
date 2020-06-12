<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResEmployedDepartment;

class ResEmployedDepartmentSearch extends ResEmployedDepartment
{
    public function rules()
    {
        return [
           [['name', 'complete_name', 'note'], 'string'],
            [['company_id', 'active', 'parent_id', 'manager_id'], 'integer'],
            [['create_date'], 'safe'],
            
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ResEmployedDepartment::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'name' => $this->name,
            'complete_name' => $this->complete_name,
            'active' => $this->active,
            'company_id' => $this->company_id,
            'parent_id' => $this->parent_id,
            'manager_id' => $this->manager_id,
            'note' => $this->note,
            'create_date' => $this->create_date,
            
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'complete_name', $this->complete_name])
            ->andFilterWhere(['like', 'active', $this->active])
            ->andFilterWhere(['like', 'company_id', $this->company_id])
            ->andFilterWhere(['like', 'parent_id', $this->parent_id])
            ->andFilterWhere(['like', 'manager_id', $this->manager_id])
            ->andFilterWhere(['like', 'note', $this->note])
            ->andFilterWhere(['like', 'create_date', $this->create_date]);

        return $dataProvider;
    }
}
