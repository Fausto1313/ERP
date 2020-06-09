<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ProductProduct;

class ProductProductSearch extends ProductProduct
{
    public function rules()
    {
        return [
            [['id', 'message_main_attachment_id', 'active', 'product_tmpl_id', 'can_image_variant_1024_be_zoomed', 'create_uid', 'write_uid'], 'integer'],
            [['default_code', 'barcode', 'combination_indices', 'create_date', 'write_date'], 'safe'],
            [['volume', 'weight'], 'number'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ProductProduct::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'message_main_attachment_id' => $this->message_main_attachment_id,
            'active' => $this->active,
            'product_tmpl_id' => $this->product_tmpl_id,
            'volume' => $this->volume,
            'weight' => $this->weight,
            'can_image_variant_1024_be_zoomed' => $this->can_image_variant_1024_be_zoomed,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
        ]);

        $query->andFilterWhere(['like', 'default_code', $this->default_code])
            ->andFilterWhere(['like', 'barcode', $this->barcode])
            ->andFilterWhere(['like', 'combination_indices', $this->combination_indices])
            ;

        return $dataProvider;
    }
}
