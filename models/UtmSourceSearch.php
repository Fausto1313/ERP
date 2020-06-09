<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\UtmSource;
class UtmSourceSearch extends UtmSource
{
    public function rules()
    {
        return [
            [['id', 'create_uid', 'write_uid'], 'integer'],
            [['name', 'create_date', 'write_date'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = UtmSource::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ;

        return $dataProvider;
    }
}
