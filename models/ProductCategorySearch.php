<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ProductCategory;

class ProductCategorySearch extends ProductCategory
{
    public function rules()
    {
        return [
            [['id', 'parent_id', 'create_uid', 'write_uid', 'removal_strategy_id'], 'integer'],
            [['parent_path', 'name', 'complete_name', 'create_date', 'write_date', 'trial362'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ProductCategory::find();

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'parent_id' => $this->parent_id,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'removal_strategy_id' => $this->removal_strategy_id,
        ]);

        $query->andFilterWhere(['like', 'parent_path', $this->parent_path])
            ->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'complete_name', $this->complete_name])
            ->andFilterWhere(['like', 'trial362', $this->trial362]);

        return $dataProvider;
    }
}
