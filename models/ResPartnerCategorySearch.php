<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResPartnerCategory;
class ResPartnerCategorySearch extends ResPartnerCategory
{
    public function rules()
    {
        return [
            [['id', 'color', 'parent_id', 'active', 'create_uid', 'write_uid'], 'integer'],
            [['parent_path', 'name', 'create_date', 'write_date', 'trial509'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ResPartnerCategory::find();

 
        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'color' => $this->color,
            'parent_id' => $this->parent_id,
            'active' => $this->active,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
        ]);

        $query->andFilterWhere(['like', 'parent_path', $this->parent_path])
            ->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'trial509', $this->trial509]);

        return $dataProvider;
    }
}
